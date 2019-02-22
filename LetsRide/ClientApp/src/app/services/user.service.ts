import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestOptions, Headers } from '@angular/http';

const baseUrl = 'api/Users/'
const getTaskAssigneesByGroupIdRoute = 'GetTaskAssigneesByGroupId/';
const getTaskAssigneesByIdRoute = 'GetTaskAssigneesById/';
const createTaskAssigneeRoute = 'CreateTaskAssignee';
const deleteTaskAssigneeRoute = 'DeleteTaskAssignee/'
const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class UserService {
    constructor(private httpClient: HttpClient) {

    }
    getUserById(id) {
        return this.httpClient.get(baseUrl + id);
    }

    createUser(user) {
        return this.httpClient.post(baseUrl, JSON.stringify(user), httpOptions);
    }

    login(user) {
        return this.httpClient.post(baseUrl, JSON.stringify(user), httpOptions);

    }

}