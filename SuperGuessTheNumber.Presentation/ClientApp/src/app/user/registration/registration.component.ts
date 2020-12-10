import { UserService } from 'src/app/shared/user/user.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  error = ''

  constructor(public service: UserService,private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {          
          this.service.formModel.reset();
          localStorage.setItem('token', res.token);
          this.toastr.success('New user created!', 'Registration successful.');
         // this.router.navigateByUrl('/home');
         console.log(res);
      },
      err => {
        if (err.status == 400)
         this.toastr.error(this.error = err.error.message, 'Registration failed');
        if (err.status == 500)
         this.toastr.error(this.error = err.error.message, 'Registration failed');
       else
         console.log(err);
      }
   );
  }
}