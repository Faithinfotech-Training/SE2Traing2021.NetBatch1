import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { CRMService } from '../shared/crm.service';
import { ActivatedRoute } from '@angular/router';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-editresource',
  templateUrl: './editresource.component.html',
  styleUrls: ['./editresource.component.css']
})

export class EditresourceComponent implements OnInit {
  courseDetails: any = {};
  url="http://localhost:25083/api/Resource/UpdateResource";

  editresourceForm = new FormGroup({
    resourceId: new FormControl(''),
    resourceName: new FormControl(''),
    resourceStatus:new FormControl(''),
    resRecordDate:new FormControl(''),
    resourceType:new FormControl('')
    // role:['',Validators.required],
  })

  constructor(private crmservice:CRMService,private formBuilder: FormBuilder,private router:ActivatedRoute,private httpclient:HttpClient) { }

  ngOnInit(): void {
    
      this.editresourceForm = new FormGroup({
        
    resourceName: new FormControl(''),
    resourceStatus:new FormControl(''),
    resRecordDate:new FormControl(''),
    resourceType:new FormControl(''),
        resourceId:new FormControl('')
         
       
     });

     const courseDetails = localStorage.getItem( 'resource-enquiry'  );

    if( courseDetails ){
      this.courseDetails = JSON.parse( courseDetails );
      console.log( this.courseDetails );
      localStorage.removeItem( 'resource-enquiry'  );
    }

    for (const key in this.courseDetails) {
      if (this.courseDetails.hasOwnProperty(key)) {
        const value = this.courseDetails[key];
        this.editresourceForm.patchValue({[key] : value });
      }
    }
  }


  onSubmit()
  {
    console.log("EnquiryForm");
    console.log("form data",this.editresourceForm.value)
    alert("Do you want to Update");
     this.httpclient.put(this.url, JSON.stringify( this.editresourceForm.value ), {
       headers: {
        'Content-Type': 'application/json'
       }
     }).subscribe((data)=>{
       console.log("asdasdfd",data)  
       alert("Do you want to Update");
  });
  }

}










