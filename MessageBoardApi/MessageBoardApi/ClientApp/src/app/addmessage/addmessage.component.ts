import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addmessage',
  templateUrl: './addmessage.component.html',
  styleUrls: ['./addmessage.component.css']
})
export class AddmessageComponent {
  messageText: string = "";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private _router: Router, private route: ActivatedRoute) {
  
  }

  addMessage() {
    const Http = new XMLHttpRequest();
    const url = 'https://localhost:44379/api/Message/' + this.messageText;
    Http.open("POST", url);
    Http.send();
    Http.onreadystatechange = (e) => {
      this._router.navigate(['/messagelist']);
    }
  }
  Back() {
    this._router.navigate(['/messagelist']);
  }
}
