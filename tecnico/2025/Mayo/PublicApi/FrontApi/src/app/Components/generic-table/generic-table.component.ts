import { CommonModule } from '@angular/common';
import { Component, computed, EventEmitter, Input, Output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { GatewayService } from '../../services/gateway/gateway.service';

export interface Task {
  name: string;
  completed: boolean;
  subtasks?: Task[];
}


@Component({
  selector: 'app-generic-table',
  imports: [
    CommonModule,
    MatSlideToggle,
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatCheckboxModule,
    FormsModule
  ],
  templateUrl: './generic-table.component.html',
  styleUrl: './generic-table.component.css'
})
export class GenericTableComponent<T> {
  @Input() title: string = '';
  @Input() dataSource: any[] = [];
  @Input() displayedColumns: string[] = [];
  
  @Input() columns: { key: string, label: string }[] = [];

  @Output() onEdit = new EventEmitter<any>();
  @Output() onDelete = new EventEmitter<any>();
  @Output() onToggleStatus = new EventEmitter<any>();
  @Output() onCreate = new EventEmitter<void>();
  @Output() onAdd = new EventEmitter<void>();
  @Output() onSaveSelected = new EventEmitter<any[]>();
  selectedItems: T[] = [];
  verGuardados: boolean = false;
  constructor(private gatewayService: GatewayService) { }

  emitEdit(item: any) {
    this.onEdit.emit(item);
  }

  emitDelete(item: any) {
    this.onDelete.emit(item);
  }

  emitToggle(item: any) {
    this.onToggleStatus.emit(item);
  }

  emitCreate() {
    this.onCreate.emit();
  }

  emitAdd(item: any) {
    this.onAdd.emit(item);
  }


  isSelected(item: any): boolean {
    return this.selectedItems.includes(item);
  }

  toggleSeleccion(item: any, checked: boolean) {
   item.id = 0;
   item.isDeleted = false;
    if (checked) {
      this.selectedItems.push(item);
    } else {
      this.selectedItems = this.selectedItems.filter(i => i !== item);
    }
  }

  isAllSelected(): boolean {
    return this.dataSource.length > 0 && this.dataSource.every(i => this.isSelected(i));
  }

  isPartiallySelected(): boolean {
    const count = this.selectedItems.length;
    return count > 0 && count < this.dataSource.length;
  }

  toggleAllSelection(checked: boolean) {
    if (checked) {
      this.selectedItems = [...this.dataSource];
    } else {
      this.selectedItems = [];
    }
  }

  enviarSeleccionadosAlGateway() {
    this.onSaveSelected.emit(this.selectedItems);
  }
}
