import { Component, OnInit, SimpleChanges } from '@angular/core';
import { CRMService } from '../shared/crm.service';

@Component({
  selector: 'app-acourseenquiry',
  templateUrl: './acourseenquiry.component.html',
  styleUrls: ['./acourseenquiry.component.css']
})
export class AcourseenquiryComponent implements OnInit {
  courses: any;
  selectedEnquiry: any;
  showModal: boolean = false;

  constructor(private crmservice:CRMService) { }

  ngOnInit(): void {
    this.crmservice.getCourseEnquiry().subscribe((data)=>{
      this.courses=data;
      console.log("getCourses=",this.courses)
    });
  }

  hideModal() {
    this.showModal = false;
  }

  getIndex( event: any ) {
    // Because courses are 1 indexed and we want 0 indexed array
    const index = event.target.getAttribute('data-index');

    this.selectedEnquiry = this.courses[index];
    console.log(this.selectedEnquiry, "SELECT")

    localStorage.setItem( 'enquiry', JSON.stringify( this.selectedEnquiry  ) );

    this.showModal = true;
  }

}
