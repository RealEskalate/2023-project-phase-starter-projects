import { useEffect } from 'react';
import { toast } from 'react-toastify';

interface ToastProps {
  message: string;
}

const Toast: React.FC<ToastProps> = ({ message }) => {
  useEffect(() => {
    toast.success(message, {
      
      autoClose: 3000, // Display toast for 2 seconds
      position: toast.POSITION.TOP_CENTER,
    });
  }, [message]);

  return null;
};

export default Toast;