import { useEffect } from 'react';
import { toast } from 'react-toastify';

interface ToastProps {
  message: string;
  isError:boolean
}

const Toast: React.FC<ToastProps> = ({ message, isError }) => {
  useEffect(() => {
    if (!isError){
      toast.success(message, {
        autoClose: 4000, 
        position: toast.POSITION.TOP_CENTER,
      });
    }else{
      toast.error(message, {
        autoClose: 4000, 
        position: toast.POSITION.TOP_CENTER,
      })
    }
  }, [message]);

  return null;
};

export default Toast;