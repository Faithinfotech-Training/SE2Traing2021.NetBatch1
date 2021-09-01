import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { CRMService } from '../shared/crm.service';
import { ActivatedRoute } from '@angular/router';
import {HttpClient} from '@angular/common/http';
//import { throwError } from 'rxjs';
//import { catchError, tap } from 'rxjs/operators';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable, Subject, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
const STR_TO_SEARCH ="ERROR POST"
const error = {
  "phone": [
      "Not a valid phone number"
  ]
}

@Component({
  selector: 'app-resource-enquiry',
  templateUrl: './resource-enquiry.component.html',
  styleUrls: ['./resource-enquiry.component.css']
})
export class ResourceEnquiryComponent implements OnInit {
  [x: string]: any;
  
  adminenquiry:any;
  courses:any;
  ageError: string;

  url="http://localhost:25083/api/ResourceEnquiry/AddResourceEnquiry";

  resourceenquiryForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    phone:new FormControl(''),
    enquiryDate:new FormControl(''),
    resourceId:new FormControl(''),
    resEnquiryStatus:new FormControl('')
    // role:['',Validators.required],
  })

  constructor(private crmservice:CRMService,
    private formBuilder: FormBuilder,private router:ActivatedRoute,private httpclient:HttpClient) { }

  ngOnInit(): void {
    this.crmservice.getCurrentData1(this.router.snapshot.params.resourceId).subscribe((data)=>
     {
       console.log("KB",this.router.snapshot.params.resourceId)
      this.resourceenquiryForm = new FormGroup({
        name: new FormControl(''),
        email: new FormControl(''),
        phone:new FormControl(''),
        enquiryDate:new FormControl(''),
        resEnquiryStatus:new FormControl(''),
        resourceId:new FormControl(data['resourceId'])
         
       })
     });
  }

  handleError(e: Response | any) {
    console.log( e );

    const errorObj = e.error.errors;
    for (const key in errorObj) {
      if (errorObj.hasOwnProperty(key)) {
        const element = errorObj[key];

        if( 'age' === key ) {
          this.ageError = element[0];
        }
        if( 'phone' === key ){
          this.phoneError = element[0];
        }
        if( 'testScore' === key ){
          this.scoreError = element[0]
        }
        console.log( element, STR_TO_SEARCH ); 
        
      }
    }
    return throwError;
}


  // onSubmit()
  // {
  //   console.log("EnquiryForm");
  //   console.log(this.resourceenquiryForm.value)
  //   this.http.post(this.url,this.resourceenquiryForm.value).subscribe((data)=>{
  //     console.warn(data)
  //   })
  // }

  onSubmit()
  {
    console.log("EnquiryForm");
    console.log("form data",this.resourceenquiryForm.value)


    this.httpclient.post<Response>(this.url, this.resourceenquiryForm.value)
          .pipe(
            catchError(e => this.handleError(e)), 
            tap(responseData => {
            console.log( responseData )
  }))
      .subscribe()  
      try {
        this.httpclient.post(this.url,this.resourceenquiryForm.value).subscribe((data: any)=>{
          console.log("asdasdfd",data)
          console.log( data.status )  
          this.resourceenquiryForm.reset();
     });
      } catch (error) {
          console.log(error)
      }
    
 this.resourceenquiryForm.reset();
 //alert("Enquiry Submited");
}
}
