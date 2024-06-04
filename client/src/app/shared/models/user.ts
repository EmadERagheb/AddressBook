export interface User {
  userId: string;
  displayName: string;
  token: string;
  refreshToken: string;
  roles: string[];
}
