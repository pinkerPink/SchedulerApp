import { ToastrService } from 'ngx-toastr';
import { TaskDetailService } from './../shared/task-detail.service';
import { Component, OnInit } from '@angular/core';
import { TaskDetail } from '../shared/task-detail.model';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styles: [
  ]
})
export class TaskDetailsComponent implements OnInit {

  constructor(public service: TaskDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: TaskDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm("Вы действительно хотите удалить эту задачу?")) {
      this.service.deleteTaskDetail(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Задача успешно удалена");
          },
          err => {
            console.log(err);
          }
        )
    }
  }

}
