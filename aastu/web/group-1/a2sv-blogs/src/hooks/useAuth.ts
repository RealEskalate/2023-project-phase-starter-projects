import { useLoginMutation, useSignupMutation } from "@/lib/redux/features/user";
import { selectAuth } from "@/lib/redux/slices/authSlice";
import { Credentials } from "@/types";
import { useSelector } from "react-redux";

export const useAuth = () => {
  const auth = useSelector(selectAuth);

  return {
    auth,
    loginHandler: async (credentials: Credentials) => {
      const [login] = useLoginMutation();
      try {
        await login(credentials);
      } catch (err) {
        return null;
      }
    },
    logoutHandler: () => {},
    signupHandler: async (credentials: Credentials) => {
      const [signup] = useSignupMutation();
      try {
        await signup(credentials);
      } catch (error) {
        return null;
      }
    },
  };
};
