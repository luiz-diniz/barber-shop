export class Employee{
    id?: number;
    cpf: string;
    name: string;
    username: string;
    password: string;
    saltPassword?: string;
    userType: string = 'default';
    hide?: boolean;
}