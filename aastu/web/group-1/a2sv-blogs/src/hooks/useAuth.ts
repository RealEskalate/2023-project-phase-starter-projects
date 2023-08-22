import { selectAuth } from "@/lib/redux/slices/authSlice";
import { useSelector } from "react-redux";

export const useAuth = () => {
  const auth = useSelector(selectAuth);

  return {
    auth,
    loginHandler: () => {},
    logoutHandler: () => {},
    signupHandler: () => {},
  };
};
