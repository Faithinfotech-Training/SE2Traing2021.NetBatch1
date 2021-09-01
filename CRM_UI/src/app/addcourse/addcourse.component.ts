import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CRMService } from '../shared/crm.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-addcourse',
  templateUrl: './addcourse.component.html',
  styleUrls: ['./addcourse.component.css']
})
export class AddcourseComponent implements OnInit {
  url="http://localhost:25083/api/Course/AddCourse";

  editcourseForm = new FormGroup({
    courseName: new FormControl(''),
    courseDescription: new FormControl(''),
    courseDuration:new FormControl(''),
    courseStatus:new FormControl(''),
    
    couresId:new FormControl('0')
    // role:['',Validators.required],
  });

  constructor(private crmservice:CRMService,private router:ActivatedRoute,private httpclient:HttpClient) { }

  ngOnInit(): void {
    this.crmservice.getCurrentData(this.router.snapshot.params.courseId).subscribe((data)=>
     {
       console.log("Ab",this.router.snapshot.params.courseId)
      this.editcourseForm = new FormGroup({
        couresId:new FormControl('0'),  
        courseName: new FormControl('courseName'),
        courseDescription: new FormControl('courseDescription'),
        courseDuration:new FormControl('courseDuration'),
        courseStatus:new FormControl('courseStatus'),    
      
        
         // role:['',Validators.required],
       });
     });
  }

  onSubmit()
  {
    console.log("EnquiryForm");
    console.log("form data",this.editcourseForm.value)
    
     this.httpclient.post(this.url,this.editcourseForm.value).subscribe((data)=>{
       console.log("asdasdfd",data) ;
       
  });
  this.editcourseForm.reset();
  }
}
