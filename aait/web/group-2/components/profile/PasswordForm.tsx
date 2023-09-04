import { useEffect, useState } from "react";

export default function PasswordForm() {
  const style =
    "border-gray-400 text-secondary-text px-4 pr-16 py-1 rounded-md m-5 bg-slate-200 focus:outline-none";
  const [isCurPasswordActive, setIsCurPasswordActive] = useState(false);
  const [isNewPasswordActive, setIsNewPasswordActive] = useState(false);
  const [isConfirmPasswordActive, setIsConfirmPasswordActive] = useState(false);

  const togglePasswordVisibility = (field:string) => {
    if (field === "current") {
      setIsCurPasswordActive(!isCurPasswordActive);
    } else if (field === "new") {
      setIsNewPasswordActive(!isNewPasswordActive);
    } else if (field === "confirm") {
      setIsConfirmPasswordActive(!isConfirmPasswordActive);
    }
  };

  return (
    <>
      <div className="flex justify-between mt-8 m-4 border-b border-slate-100 pb-4">
        <div>
          <p className="text-lg font-medium text-gray-900">
            Manage Your Account
          </p>
          <p className="text-sm font-light text-gray-600">
            You can change your password here
          </p>
        </div>
        <div>
          <button className="bg-blue-800 text-white px-6 py-1 rounded-md">
            Save Changes
          </button>
        </div>
      </div>
      {/* <hr className="bg-slate-800" /> */}
      <div className="flex justify-center items-center">
        <div>
          <form>
            <div className="flex justify-between items-center">
              <label className="mr-5">Current Password</label>
              <input
                type={isCurPasswordActive ? "text" : "password"}
                placeholder="Enter your current password"
                className={style}
                onClick={() => togglePasswordVisibility("current")}
              />
            </div>
            <div className="flex justify-between items-center">
              <label>New Password</label>
              <input
                type={isNewPasswordActive ? "text" : "password"}
                placeholder="Enter new password"
                className={style}
                onClick={() => togglePasswordVisibility("new")}
              />
            </div>
            <div className="flex justify-between items-center">
              <label>Confirm Password</label>
              <input
                type={isConfirmPasswordActive ? "text" : "password"}
                placeholder="Confirm new password"
                className={style}
                onClick={() => togglePasswordVisibility("confirm")}
              />
            </div>
          </form>
        </div>
      </div>
    </>
  );
}
