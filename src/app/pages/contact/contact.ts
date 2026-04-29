import { Component, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-contact',
  imports: [FormsModule],
  templateUrl: './contact.html',
  styleUrl: './contact.scss'
})
export class Contact {
  submitted: boolean = false;
  sending: boolean = false;
  error: string = '';

  formData: { name: string; email: string; message: string } = {
    name: '',
    email: '',
    message: ''
  };

  constructor(private contactService: ContactService, private cdr: ChangeDetectorRef) {}

  onSubmit(): void {
    this.sending = true;
    this.error = '';

    this.contactService.send(this.formData).subscribe({
      next: (res) => {
        console.log('Success:', res);
        this.submitted = true;
        this.sending = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.log('Error:', err);
        this.error = 'Something went wrong. Please try again.';
        this.sending = false;
        this.cdr.detectChanges();
      }
    });
  }
}