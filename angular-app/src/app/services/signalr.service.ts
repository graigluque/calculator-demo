import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { environment } from 'src/environments/environment';


const resultData = {
  messages: [{}],
  ready: false
}

@Injectable({
  providedIn: 'root'
})

export class SignalrService {

  // connReady: boolean = false;

  // public RESULT: string = "";

  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.apiBaseUrl + '/api')
      .configureLogging(signalR.LogLevel.Information)
      .build();
    // this.hubConnection.onclose(this.reconnect);
  }

  private methods: string[] = [];

  connectOn(methodName: string, newMethod: (...args: any[]) => void) {
    this.hubConnection.on(methodName, message => newMethod(message));
    if (this.methods.indexOf(methodName) < 0) this.methods.push(methodName);
  }

  async startConnection() {
    await this.hubConnection.start()
      .then(() => {
        console.log('Hub Connection Started!');
      })
      .catch(err => {
        console.log('Error while starting connection: ' + err);
        this.reconnect();
      });
  }

  reconnect() {
    console.log('reconnecting...');
    setTimeout(this.startConnection, 2000);
  }

  offConection() {
    // hubConnection.off("calculateResponse");
    this.methods.forEach(element => {
      this.hubConnection.off(element);
    });
  }

}
