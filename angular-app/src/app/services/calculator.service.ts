import { Injectable } from '@angular/core';
import { ServicebusService } from './servicebus.service';
import { SignalrService } from './signalr.service';

// const enum OperationType { Add, Sub, Mul, Div, Undefined }

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor(private signalr: SignalrService, private serviceBus: ServicebusService) { }

  private Operations: string[] = ['Add', 'Sub', 'Mul', 'Div', 'Undefined'];


  startConnections() {
    this.signalr.startConnection();
  }

  stopConnections() {
    this.signalr.offConection();
  }

  connectOnNewCalculation(newMethod: (...args: any[]) => void) {
    this.signalr.connectOn("newCalculation", message => newMethod(message));
  }

  async sendCalculation(firstNumber: number, secondNumber: number, operation: string) {
    // if(this.signalr.getStatus)
    var message: any = {
      firstNumber: firstNumber,
      secondNumber: secondNumber,
      operation: (this.Operations.indexOf(operation) < 0 ? 'Undefined' : operation)
    };
    console.log("Sending message to Service Bus");
    console.log(<JSON>message);
    await this.serviceBus.sendMessage(<JSON>message);
  }
}
