import { Component, OnInit } from '@angular/core';
import { CRMService } from '../shared/crm.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-acourses',
  templateUrl: './acourses.component.html',
  styleUrls: ['./acourses.component.css']
})
export class ACoursesComponent implements OnInit {
  courses: any;

  constructor(private crmservice:CRMService, private router: Router) { }

  ngOnInit(): void {
    this.crmservice.getCourses().subscribe((data)=>{
      this.courses=data;
      console.log("getCourses=",this.courses)
    });
  }

  getBtn( event: any ) {
    console.log( event );
    console.log(event.target.getAttribute('data-index'))

    // Because courses are 1 indexed and we want 0 indexed array
    const index = event.target.getAttribute('data-index') - 1;
    console.log(this.courses[ index ]);

    localStorage.setItem( 'course-enquiry', JSON.stringify( this.courses[ index -1] ) );

    this.router.navigateByUrl(`/editcourse/${index + 1}`);
  }
  getBtn1()
  {
    this.router.navigateByUrl("/addcourse");
  }

}
