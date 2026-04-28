import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact',
  imports: [FormsModule],
  templateUrl: './contact.html',
  styleUrl: './contact.scss'
})
export class Contact {
  submitted: boolean = false;

  formData: { name: string; email: string; message: string } = {
    name: '',
    email: '',
    message: ''
  };

  onSubmit(): void {
    console.log('Form submitted:', this.formData);
    this.submitted = true;
  }
}