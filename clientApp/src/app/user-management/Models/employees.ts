export class Employees{
    EmpId : string | undefined
    Fullname : string | undefined
    Email : string | undefined
    Salary : string | undefined
    Joindate : string | undefined
    Password : string | undefined
    Username : string | undefined
    Phonenumber : string | undefined
    Address : string | undefined
    Status : string | undefined//-active/inactive
    TempPassword : string | undefined
    Salaries : Salaries[] = []
}


export class Salaries{
    Month : string | undefined
    Salary : string | undefined
}
