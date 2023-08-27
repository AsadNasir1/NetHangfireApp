import { numberAttribute } from "@angular/core";

/*
export interface User {
    userID: number;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    phone: string;
    address: string;
    dateCreated: Date;
  }
*/
  export class User {
    userID: number;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    NGDateOfBirth: any;
    phone: string;
    address: string;
    dateCreated: Date;
    constructor(                              
    ) {
        this.userID = 0;
        this.firstName = '';
        this.lastName = '';
        this.dateOfBirth = new Date();
        this.phone = '';
        this.address = '';
        this.dateCreated = new Date();
    }

    

  }