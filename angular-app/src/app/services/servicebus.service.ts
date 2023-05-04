import { Injectable } from '@angular/core';
import * as asb from '@azure/service-bus';
import { environment } from 'src/environments/environment';

const serviceBus = new asb.ServiceBusClient(environment.serviceBusConnectionString);
const sender = serviceBus.createSender("calculations");
const ContentTypes = {
  Text: 'text/plain',
  Xml: 'application/xml',
  Json: 'application/json',
};

@Injectable({
  providedIn: 'root'
})
export class ServicebusService {

  constructor() { }

  async sendMessage(message: any, type?: string) {

    await sender.sendMessages({
      body: message,
      contentType: (type ?? ContentTypes.Json)
    });
  }
}
