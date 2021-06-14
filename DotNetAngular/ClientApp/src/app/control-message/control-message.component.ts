import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-control-message',
  templateUrl: './control-message.component.html',
  styleUrls: ['./control-message.component.css']
})
export class ControlMessageComponent implements OnInit {

  textMessage: string = ""
  testFlag: boolean = true
  counter: number = 0

  incrementCounter() {
    this.counter += 1
  }

  constructor() { }

  ngOnInit() {
  }

}
