export interface IUserSignUpDto {
    email: string | null;
    password: string | null;
    confirmPassword:string | null;
    firstName: string | null;
    lastName: string | null;
    phoneNumber: string | null;
    birth: string | null;
    gender: string | null;
}

export interface IGender{
    number:number,
    name:string
}