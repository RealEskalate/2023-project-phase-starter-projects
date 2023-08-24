import { useLoginMutation, useSignupMutation } from "@/lib/redux/features/user";
import { selectAuth } from "@/lib/redux/slices/authSlice";
import { Credentials } from "@/types";
import { useSelector } from "react-redux";

export const useAuth = () => {
  const auth = useSelector(selectAuth);
  const [login] = useLoginMutation();
  const [signup] = useSignupMutation();

  return {
    auth,
    loginHandler: async (credentials: Credentials) => {
      try {
        await login(credentials);
      } catch (err) {
        return null;
      }
    },
    logoutHandler: () => {},
    signupHandler: async (credentials: Credentials) => {
      try {
        await signup(credentials);
      } catch (error) {
        return null;
      }
    },
  };
};
