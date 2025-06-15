import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { MonacoEditorModule } from 'ngx-monaco-editor-v2';
import { FormsModule } from '@angular/forms';
import { JsonItem } from './json-item';

@Component({
  selector: 'app-dashboard',
  imports: [FormsModule, MonacoEditorModule],
  templateUrl: './app-dashboard.component.html',
  styleUrl: './app-dashboard.component.scss',
})
export class DashboardComponent {
  listOfJsons: string[] = [];
  code: string = '';
  currentJson: string = '';
  editorOptions = { theme: 'vs-dark', language: 'json' };

  constructor(private httpClient: HttpClient) {}

  loadJsons(): void {
    this.getListJsonsFromApi().subscribe((result: JsonItem[]) => {
      console.log(result);
      this.listOfJsons = result.map(x=>x.fileName);
    });
  }

  getJsonContent(name: string): void {
    this.currentJson = name;
    this.getJsonContentFromApi(name).subscribe((result: string) => {
      this.code = result;
    });
  }

  exportJsonFile(): void {}

  newJson(): void {
    this.currentJson = 'new.json';
    this.code = '';
  }

  updateJson(): void {}

  uploadJson(): void {}

  // to service
  // export
  getListJsonsFromApi(): Observable<JsonItem[]> {
    return this.httpClient.get<JsonItem[]>('http://localhost:5271/Items/List');
  }
  getJsonContentFromApi(fileName: string): Observable<string> {
    const options = {
      responseType: 'text' as 'json',
    };
    return this.httpClient.get<string>(
      'http://localhost:5271/Export/String?fileName=' + fileName,
      options
    );
  }

  //import
  importJsonByApi(fileName: string, content: string): void {
    //this.httpClient.post
  }
}
