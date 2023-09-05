"use client"
import { RootState } from '@/store';
import { useEffect } from 'react'; // Import useEffect
import { useSelector } from 'react-redux';
import { useRouter } from 'next/navigation';

const Authenticate = ({ children }: { children: React.ReactNode }) => {
  const user = useSelector((state: RootState) => state.user.user);
  const router = useRouter();

  useEffect(() => {
    if (!user) {
      router.push("/signin");
    }
  }, [user, router]); 

  return <>{children}</>;
};

export default Authenticate;
