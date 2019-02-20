import { Component, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-messagelist',
  templateUrl: './messagelist.component.html',
  styleUrls: ['./messagelist.component.css']
})
export class MessagelistComponent {

  public messages: Array<any> = [];
  public baseurl = "";
  public apipath = "api/Messages";
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private _router: Router) {
    this.baseurl = baseUrl;
    this.getMessages();
  }
  GetComments(msgId: any) {
    this._router.navigate([`/comments/${msgId}`]);
  }
  AddComment(msgId: any) {
    this._router.navigate([`/addcomment/${msgId}`]);
  }
  AddMessage() {
    this._router.navigate(['/addmessage']);
  }
  getMessages() {
    this.http.get("https://localhost:44379/api/MessagesBoard").subscribe((response: Response) => {
      this.messages = response.json();
    });
  }
  likeMessage(id: any) {
    const Http = new XMLHttpRequest();
    const url = 'https://localhost:44379/api/MessagesBoard/'+id;
    Http.open("POST", url);
    Http.send();
    Http.onreadystatechange = (e) => {
      this.getMessages();
    }
  }
}
