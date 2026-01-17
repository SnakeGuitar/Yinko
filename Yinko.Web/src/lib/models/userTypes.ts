export interface CreateUserRequest {
    identityId: string;
    username: string;
    email: string;
    avatarUrl?: string;
}

export interface UserDto {
    id: number;
    username: string;
    email: string;
    inkosBalance: number;
    currentStreak: number;
}