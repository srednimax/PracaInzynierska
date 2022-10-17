export interface IUserSignUpDto {
    email: string | null;
    confirmEmail: string | null;
    password: string | null;
    firstName: string | null;
    lastName: string | null;
    phoneNumber: string | null;
    birth: string | null;
    gender: string;
}

export interface IGender{
    number:number,
    name:string
}