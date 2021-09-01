import { Component, OnInit } from '@angular/core';
import { CRMService } from '../shared/crm.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-aresources',
  templateUrl: './aresources.component.html',
  styleUrls: ['./aresources.component.css']
})
export class AresourcesComponent implements OnInit {
  resources:any

  constructor(private crmservice:CRMService,private router: Router) { }

  ngOnInit(): void {
    this.crmservice.getResources().subscribe((data)=>{
      this.resources=data;
      console.log("getResources=",this.resources)
    });
  }
  getBtn( event: any ) {
    console.log( event );
    console.log(event.target.getAttribute('data-index'))

    // Because courses are 1 indexed and we want 0 indexed array
    const index = event.target.getAttribute('data-index') - 1;
    console.log(this.resources[ index ]);

    localStorage.setItem( 'resource-enquiry', JSON.stringify( this.resources[ index ] ) );

    this.router.navigateByUrl(`/editresource/${index + 1}`);
  }

}
