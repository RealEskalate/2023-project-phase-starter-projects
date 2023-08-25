import userApi from "../services/userApi";

export const {
  useLoginMutation,
  useSignupMutation,
  useChangePasswordMutation,
  useEditProfileMutation,
} = userApi;
