# Planora
## API Endpoints

### Projects

| Method | Endpoint            | Description       |
| ------ | ------------------- | ----------------- |
| GET    | `/api/project`      | Get all projects  |
| GET    | `/api/project/{id}` | Get project by id |
| POST   | `/api/project`      | Create project    |
| PUT    | `/api/project/{id}` | Update project    |
| DELETE | `/api/project/{id}` | Delete project    |

### Tasks

| Method | Endpoint                          | Description           |
| ------ | --------------------------------- | --------------------- |
| GET    | `/api/task/{id}`                  | Get task by id        |
| GET    | `/api/projects/{projectId}/tasks` | Get all project tasks |
| POST   | `/api/projects/{projectId}/tasks` | Create task           |
| PUT    | `/api/task/{id}`                  | Update task           |
| DELETE | `/api/task/{id}`                  | Delete task           |

### Notes

| Method | Endpoint                          | Description           |
| ------ | --------------------------------- | --------------------- |
| GET    | `/api/note/{id}`                  | Get note by id        |
| GET    | `/api/projects/{projectId}/notes` | Get all project notes |
| POST   | `/api/projects/{projectId}/notes` | Create note           |
| PUT    | `/api/note/{id}`                  | Update note           |
| DELETE | `/api/note/{id}`                  | Delete note           |

### Ideas

| Method | Endpoint                          | Description           |
| ------ | --------------------------------- | --------------------- |
| GET    | `/api/idea/{id}`                  | Get idea by id        |
| GET    | `/api/projects/{projectId}/ideas` | Get all project ideas |
| POST   | `/api/projects/{projectId}/ideas` | Create idea           |
| PUT    | `/api/idea/{id}`                  | Update idea           |
| DELETE | `/api/idea/{id}`                  | Delete idea           |

### Links

| Method | Endpoint                          | Description           |
| ------ | --------------------------------- | --------------------- |
| GET    | `/api/link/{id}`                  | Get link by id        |
| GET    | `/api/projects/{projectId}/links` | Get all project links |
| POST   | `/api/projects/{projectId}/links` | Create link           |
| PUT    | `/api/link/{id}`                  | Update link           |
| DELETE | `/api/link/{id}`                  | Delete link           |
