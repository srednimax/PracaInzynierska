import { Injectable } from "@angular/core";
import { MessageService } from "primeng/api";


@Injectable()
export class ExtraFunctions{

    constructor(private messageService:MessageService){}

    showToast(severity: string, summary: string, message: string): void {
        this.messageService.add({
          severity: severity,
          summary: summary,
          detail: message,
          life: 5000,
        });
      }

    status(stat: number): string {
        switch (stat) {
          case 0:
            return "Zamówiona";
          case 1:
            return "Zarezerwowane";
          case 2:
            return "W trakcie realizacji";
          case 3:
            return "Gotowe do obioru";
          case 4:
            return "Odebrana";
          case 5:
            return "Oddana";
          default:
            return "";
        }
      }

      genre(gen: number): string {
        switch (gen) {
          case 0:
            return "Fikcja literacka";
          case 1:
            return "Kryminał";
          case 2:
            return "Horror";
          case 3:
            return "Historyczna";
          case 4:
            return "Romans";
          case 5:
            return "Western";
          case 6:
            return "Science fiction";
          case 7:
            return "Fantasy";
          default:
            return "";
        }
      }
}