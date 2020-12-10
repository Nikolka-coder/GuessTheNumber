import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
 
  constructor(private fb: FormBuilder, private http: HttpClient, private toastr: ToastrService) { }

  GetAllHistoryGames(){    
   return this.http.get<any>("https://localhost:5001/GetAllHistoryGames");
  }

  GetHistoryOfCurrentGame(){    
    return this.http.get<any>("https://localhost:5001/GetHistoryOfCurrentGame");
  }

}
