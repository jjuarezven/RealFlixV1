import {
  Component,
  OnInit,
  Input,
  OnChanges,
  SimpleChanges,
  Output,
  EventEmitter,
} from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { Show } from '../models/show';
import { ShowsService } from '../services/shows-service';
import { SelectItem } from 'primeng/api/selectitem';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css'],
})
export class ShowComponent implements OnInit, OnChanges {
  @Input() show: Show;
  @Input() languageOptions: SelectItem[];
  @Input() genreOptions: SelectItem[];
  @Input() channelOptions: SelectItem[];
  @Output() updateShowsInfo: EventEmitter<Show> = new EventEmitter();

  showForm: FormGroup;
  isNew: boolean;
  constructor(private fb: FormBuilder, private showService: ShowsService) {}

  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes.show && changes.show.currentValue !== undefined) {
      this.isNew = this.show.Id === 0;
      this.showForm = this.generateFormControl(this.show);
    }
  }

  generateFormControl(showModel: Show) {
    return this.fb.group({
      Id: new FormControl(showModel ? showModel.Id : ''),
      Url: new FormControl(showModel ? showModel.Url : '', [
        Validators.required,
      ]),
      Name: new FormControl(showModel ? showModel.Name : '', [
        Validators.required,
      ]),
      Language: new FormControl(showModel ? showModel.Language : '', [
        Validators.required,
      ]),
      NetworkName: new FormControl(showModel ? showModel.NetworkName : ''),
      RatingAverage: new FormControl(showModel ? showModel.RatingAverage : 0),
      Genres: new FormControl(showModel ? showModel.Genres !== undefined && showModel.Genres !== '' ? showModel.Genres.split(',') : [] : [], [
        Validators.required,
      ]),
      Summary: new FormControl(showModel ? showModel.Summary : '', [
        Validators.required,
      ]),
    });
  }

  // gets the values stored as strings and transforms to array to set the selected items on listbox control
  setControlsSelection(showModel: Show) {
    const options = showModel.Genres.split(',');
  }

  ////#region form getters
  get UrlControl() {
    return this.showForm.controls.Url;
  }
  get NameControl() {
    return this.showForm.controls.Name;
  }
  get LanguageControl() {
    return this.showForm.controls.Language;
  }
  get RatingAverageControl() {
    return this.showForm.controls.RatingAverage;
  }
  get NetworkNameControl() {
    return this.showForm.controls.NetworkName;
  }
  get GenresControl() {
    return this.showForm.controls.Genres;
  }
  get SummaryControl() {
    return this.showForm.controls.Summary;
  }
  ////#endregion

  saveShow() {
    this.show = this.showForm.value;
    this.show.Genres = this.GenresControl.value.join();
    // sending some hardcoded values for simplicity
    this.show.Type = 'Scripted';
    this.show.KeyWords = this.isNew ? 'new' : 'updated';
    const operation = this.isNew ? this.showService.saveShow(this.show) : this.showService.updateShow(this.show);
    operation.subscribe((result) => {
      if (result) {
        if (this.isNew) {
          this.show = result;
        }
        this.updateShowsInfo.next(this.show);
      }
    });
  }

  cancel() {
    this.updateShowsInfo.next(null);
  }
}
