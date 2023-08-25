import {
  useChangePasswordMutation,
  useEditProfileMutation,
  useLoginMutation,
  useSignupMutation,
} from "@/lib/redux/features/user";
import { selectAuth, setAuth } from "@/lib/redux/slices/authSlice";
import { Credentials } from "@/types";
import { useDispatch, useSelector } from "react-redux";

export const useAuth = () => {
  const dispatch = useDispatch();
  const auth = useSelector(selectAuth);
  const [login] = useLoginMutation();
  const [signup] = useSignupMutation();
  const [changePassword] = useChangePasswordMutation();
  const [editProfile, { isLoading, error, isSuccess }] =
    useEditProfileMutation();
  return {
    auth,
    loginHandler: async (credentials: Credentials) => {
      try {
        return await login(credentials);
      } catch (err) {
        return null;
      }
    },
    logoutHandler: () => {
      localStorage.removeItem("auth");
      document.cookie = "";
      dispatch(setAuth(null));
    },
    signupHandler: async (credentials: Credentials) => {
      try {
        return await signup(credentials);
      } catch (error) {
        return null;
      }
    },
    editProfileHandler: async (data: FormData) => {
      console.log(data);
      try {
        return await editProfile(data);
      } catch (error) {
        return null;
      }
    },
    changePasswordHandler: async (passwords: any) => {
      try {
        return await changePassword(passwords);
      } catch (error) {
        return null;
      }
    },
  };
};
