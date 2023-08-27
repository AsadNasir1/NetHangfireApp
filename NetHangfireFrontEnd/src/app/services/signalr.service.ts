import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  hubUrl: string;
  connection: any;
  data: User;

  constructor()
  { 
    this.data = new User();
    this.hubUrl = 'https://localhost:7267/newUser'; 
  }

  public async initiateSignalrConnection(): Promise<void> {
    try {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(this.hubUrl)
        .withAutomaticReconnect()
        .build();

      await this.connection.start({ withCredentials: false });

      console.log(`SignalR connection success! connectionId: ${this.connection.connectionId}`);
    }
    catch (error) {
      console.log(`SignalR connection error: ${error}`);
    }
  }

}