import { Component, OnInit, ViewChild } from "@angular/core";
import { ConfirmationService } from "primeng/api";
import { Table } from "primeng/table";
import { IGenreAddDto } from "src/Dtos/Genre/IGenreAddDto";
import { IGenreDto } from "src/Dtos/Genre/IGenreDto";
import { IGenreUpdateDto } from "src/Dtos/Genre/IGenreUpdateDto";
import { ExtraFunctions } from "src/services/extraFunctions";
import { GenreService } from "src/services/genreService";

@Component({
  selector: "app-employee-genre",
  templateUrl: "./employee-genre.component.html",
  styleUrls: ["./employee-genre.component.css"],
})
export class EmployeeGenreComponent implements OnInit {
  genres: IGenreDto[];
  genreEdit: IGenreDto;
  genreAdd: IGenreAddDto = {
    name: "",
  };
  @ViewChild("dt") dt: Table | undefined;

  genreDialogEdit: boolean;
  submittedGenreEdit: boolean;

  genreDialogAdd: boolean;
  submittedGenreAdd: boolean;

  constructor(
    public extraFunctions: ExtraFunctions,
    private confirmationService: ConfirmationService,
    private genreService: GenreService
  ) {}

  ngOnInit(): void {
    this.genreService.getAll().subscribe((resp) => {
      this.genres = resp;
    });
  }

  addGenre(): void {
    this.genreDialogAdd = true;
    this.submittedGenreAdd = false;
  }

  hideDialogGenre(): void {
    this.genreDialogAdd = false;
    this.submittedGenreAdd = false;
  }

  saveGenre(): void {
    this.submittedGenreAdd = true;
    this.genreService.addGenre(this.genreAdd).subscribe({
      next: (resp) => {
        this.genres.push(resp);
        this.extraFunctions.showToast(
          "success",
          "Sukces",
          "Udało się dodać nowy gatunek książki."
        );
        this.genreAdd.name = "";
        this.genreDialogAdd = false;
      },
      error: (error) => {
        if (error === "The genre already exist") {
          this.extraFunctions.showToast(
            "error",
            "Błąd",
            "Taki gatunek książki już istnieje."
          );
        }
      },
    });
  }

  deleteGenre(genre: IGenreDto): void {
    this.confirmationService.confirm({
      message: "Czy napewno chcesz usunąć gatunek książki?",
      header: "Potwierdzenie",
      icon: "pi pi-exclamation-triangle",
      acceptLabel: "Tak",
      rejectLabel: "Nie",
      accept: () => {
        this.genreService.deleteGenre(genre.id).subscribe((resp) => {
          this.genres = this.genres.filter((x) => x.id !== resp.id);
          this.extraFunctions.showToast(
            "success",
            "Sukces",
            "Udało się usunąć gatunek książki."
          );
        });
      },
    });
  }

  hideDialogGenreEdit(): void {
    this.genreDialogEdit = false;
    this.submittedGenreEdit = false;
  }
  editGenre(genre: IGenreDto): void {
    this.genreEdit = { ...genre };
    this.genreDialogEdit = true;
  }
  saveGenreEdit(): void {
    this.submittedGenreEdit=true;
    let data:IGenreUpdateDto={
      id: this.genreEdit.id,
     name : this.genreEdit.name
    }

    this.genreService.updateGenre(data).subscribe({next:resp=>{
      this.genres[this.genres.findIndex((x) => x.id == resp.id)] = resp;
      this.extraFunctions.showToast(
        "success",
        "Sukces",
        "Udało się zaktualizować gatunek książki."
      );
      this.genreDialogEdit=false;
    },error:error=>{
      if (error === "The genre already exist") {
        this.extraFunctions.showToast(
          "error",
          "Błąd",
          "Taki gatunek książki już istnieje."
        );
      }
    }})
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
