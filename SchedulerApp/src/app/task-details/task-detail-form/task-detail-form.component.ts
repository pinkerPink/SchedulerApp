import { ToastrModule, ToastrService } from 'ngx-toastr';
import { TaskDetailService } from './../../shared/task-detail.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TaskDetail } from 'src/app/shared/task-detail.model';

@Component({
  selector: 'app-task-detail-form',
  templateUrl: './task-detail-form.component.html',
  styles: [
  ]
})
export class TaskDetailFormComponent implements OnInit {

  constructor(public service:TaskDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm) {
    if (this.service.formData.taskDetailId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postTaskDetail().subscribe(
      res => {
        this.reseetForm(form);
        this.service.refreshList();
        this.toastr.success("Задача успешно добавлена")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form :NgForm) {
    this.service.putTaskDetail().subscribe(
      res => {
        this.reseetForm(form);
        this.service.refreshList();
        this.toastr.info("Задача успешно обновлена")
      },
      err => {
        console.log(err);
      }
    );
  }

  reseetForm(form:NgForm) {
    form.form.reset;
    this.service.formData = new TaskDetail();
  }

}
