import { Component, OnInit, OnDestroy } from '@angular/core';
import { CalculatorService } from '../services/calculator.service';
import project from '../../../package.json';


@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit, OnDestroy {

  constructor(protected calculatorService: CalculatorService) {
    this.appVersion = project.version;
  }

  appVersion: string = '';
  firstText: string = '';
  secondText: string = '';
  messages: string[] = [];
  // messages: string[] = ['uno', 'dos', 'tres'];


  ngOnInit(): void {
    this.calculatorService.startConnections();
    this.calculatorService.connectOnNewCalculation(message => this.onResult(message))
  }

  ngOnDestroy(): void {
    this.calculatorService.stopConnections();
  }

  onOperationClick(operation: string) {
    // Convert inputs to numbers
    // TODO: Validate inputs
    const firstNumber: number = parseFloat(this.firstText);
    const secondNumber: number = parseFloat(this.secondText);
    console.log("firstInput.value: " + this.firstText);
    console.log("secondInput.value: " + this.secondText);

    this.calculatorService.sendCalculation(firstNumber, secondNumber, operation);
  }

  onResult(message: string) {
    console.log("newCalculation result:" + message);
    this.messages.unshift(message);
  }

  onClearClick() {
    this.firstText = '';
    this.secondText = '';
    this.messages = [];
  }
}
