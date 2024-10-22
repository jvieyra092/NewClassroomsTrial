import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-file-upload-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './file-upload-form.component.html',
  styleUrls: ['./file-upload-form.component.css']
})
export class FileUploadFormComponent implements OnInit {
  uploadForm: FormGroup;
  selectedFile: File | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.uploadForm = this.fb.group({
      format: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  
  }

  // Submit the form
  onSubmit(): void {
  
    if (this.uploadForm.valid) {
      this.http.get('https://randomuser.me/api/?nat=us&results=50')
        .subscribe(
          (response) => {
            this.queryBackend(response);
          },
          (error) => {
            console.error('Error:', error);
          }
        );

    }
  }

  queryBackend(json: any): void{
    var formData = {
      'results':json["results"],
      'format': this.uploadForm.get('format')?.value
    };

    this.http.post('https://localhost:7256/api/user/generate', formData, { responseType: 'blob' })
      .subscribe(
        (blob: Blob) => {
          const url = window.URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          a.download = 'sample'+ this.uploadForm.get('format')?.value; 
    
          document.body.appendChild(a);
          a.click();
    
          document.body.removeChild(a);
          window.URL.revokeObjectURL(url);
        },
        (error) => {
          console.error('Error:', error);
        }
      );
  }
}
