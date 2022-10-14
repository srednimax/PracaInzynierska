export interface IUserSignUpDto {
    email: string | null;
    confirmEmail: string | null;
    password: string | null;
    confirmPassword: string | null;
    firstName: string | null;
    lastName: string | null;
    phoneNumber: string | null;
    birth: string | null;
    gender: string;
}