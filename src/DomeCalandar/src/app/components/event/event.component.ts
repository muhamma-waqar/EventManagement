import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddEventCommand } from '../../../model/AddEventCommand';
import { EventService } from '../../services/event.service';

interface EventType {
  value: number;
  viewValue: string;
}


@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrl: './event.component.css'
})
export class EventComponent {
  selectedEventType: string = '';
  event : FormGroup;
  eventModel = new AddEventCommand();
  constructor(private fb: FormBuilder, private eventService : EventService)
  {
    this.event = this.fb.group({
      name:['', Validators.required],
      type:['', Validators.required],
      phone:['', Validators.required],
      address: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate:['', Validators.required],
      city:['', Validators.required],
      region:['', Validators.required],
      postalCode:['', Validators.required],
      country:['', Validators.required],
      userId:['']
    })
  }
  eventsType: EventType[] = [
    {value: 0, viewValue: 'Wedding'},
    {value: 1, viewValue: 'Metting'},
    {value: 1, viewValue: 'Conference'},
  ];


  onSubmit(){
    if(this.event.valid){
      this.event.controls['userId'].setValue("02174cf0–9412–4cfe-afbf-59f706d72cf6")
      this.eventModel = this.event.value as AddEventCommand;
      this.eventService.post(this.eventModel).subscribe(
        (response) =>{
          this.eventModel = response;
        })
      }
  }
}
