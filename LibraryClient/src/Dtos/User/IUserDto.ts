export interface IUserDto {
    id: number;
    email: string | null;
    firstName: string | null;
    lastName: string | null;
    phoneNumber: string | null;
    birth: string | null;
    gender: string;
    role: string;
    penalty: number;
}