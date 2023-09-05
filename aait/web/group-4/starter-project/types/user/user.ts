export default interface User {
    user: string;
    userName: string;
    userRole: string;
    userEmail: string;
    userProfile: string;
    token: string;
};

export interface RegisterInputData {
    name: string;
    password: string;
    email: string;
}

export interface RegisterResponseData {
    userId: string;
    token: string;
}

export interface LoginInputData {
    email: string;
    password: string;
}

export interface EditProfileData {

    email: string;
    name: string;
    image: File | null;
}

export interface EditProfileResponse {
    message: string;
    body: {
        _id: string;
        name: string;
        email: string;
        password: string;
        image: string;
        role: string;
        __v: number;
    };
}

export interface EditPasswordData{
    oldPassword: string;
    newPassword: string;
}

