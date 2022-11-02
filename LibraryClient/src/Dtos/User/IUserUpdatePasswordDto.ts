export interface IUserUpdatePasswordDto {
    id: number;
    oldPassword: string | null;
    newPassword: string | null;
    confirmNewPassword: string | null;
}