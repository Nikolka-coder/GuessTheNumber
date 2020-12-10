import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HistoryComponent } from './history/history.component';
import { HistoryService } from '../shared/history/history.service';

@Component({
  selector: 'game',
  templateUrl: './game.component.html',
  styles: [
  ]
})
export class GameComponent implements OnInit {

 public value : any
 public statusMessage :any
 public game : any

  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService, private service: HistoryService) { }
  ngOnInit(): void {
  }

  StartGame(){
    this.http.get("https://localhost:5001/StartGame?value="+this.value).subscribe(
       (res:any) => {          
        this.toastr.success('New game created!', 'Success!');
        console.log(res);
    });
  }

  CheckValue(){    
    this.http.get("https://localhost:5001/CheckValue?value="+this.value).subscribe(
      (res: any) => {          
          this.toastr.show(this.statusMessage = res.statusGameMessage);
          console.log(res);
      },
      err => { 
        if (err.status == 400)
        this.toastr.error(this.statusMessage = err.error.message, 'Please start new game.');
        else
        console.log(err);
      }
  );
  }

  FinishGame(){    
    this.http.get('https://localhost:5001/FinishGame',{responseType: 'text'}).subscribe(
      (res: any) => {          
          this.toastr.error(this.statusMessage = res);
          console.log(res);
      }
    );
  }

  onHistoryOfCurrentGame(game){
    this.router.navigate(['/historyofcurrentgame']);
    game = this.service.GetHistoryOfCurrentGame();
    }

  onAllGames(game){
    this.router.navigate(['/history']);
    game = this.service.GetAllHistoryGames();
  }
}
