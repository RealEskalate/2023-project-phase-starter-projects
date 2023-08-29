import {
  useChangePasswordMutation,
  useEditProfileMutation,
  useLoginMutation,
  useSignupMutation,
} from "@/lib/redux/features/user";
import { AuthState, selectAuth, setAuth } from "@/lib/redux/slices/authSlice";
import { Credentials } from "@/types";
import { useCookies } from "next-client-cookies";
import { useRouter } from "next/navigation";
import { useDispatch, useSelector } from "react-redux";

export const useAuth = () => {
  const dispatch = useDispatch();
  const cookies = useCookies();
  const router = useRouter();
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

    logoutHandler: async () => {
      localStorage.removeItem("auth");

      cookies.set("token", "", { path: "/", expires: Date.parse("3/10/1997") });

      const dummy: AuthState = {
        token: "",
        isAuthenticated: false,
        isLoading: false,
        userId: "",
        userName: "",
        userRole: "",
        userProfile: "",
        userEmail: "",
        error: null,
      };

      dispatch(setAuth(dummy));

      router.refresh();
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
