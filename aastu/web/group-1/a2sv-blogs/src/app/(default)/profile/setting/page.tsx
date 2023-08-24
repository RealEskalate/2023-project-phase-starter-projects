export default function page() {
  return (
    <section className="mt-4">
      <div className="flex justify-between items-center">
        <div className="space-y-2">
          <h1 className="sm:text-lg font-bold text-neutral-600">
            Manage Your Account
          </h1>
          <p className="text-sm max-w-[20ch] text-neutral-500">
            You can change your password here
          </p>
        </div>
        <div>
          <button className="px-3 py-1 bg-blue-800 text-white rounded">
            Save Changes
          </button>
        </div>
      </div>
      <div className="h-full">
        <div className="lg:w-1/3 mx-auto mt-20">
          <div className="mt-5 grid grid-cols-6 items-center">
            <label
              htmlFor="password"
              className="text-sm text-neutral-500 col-span-2"
            >
              Current Password
            </label>
            <input
              type="password"
              id="current_password"
              placeholder="Enter your current password"
              className="col-span-4 border border-neutral-200 rounded px-3 py-1 mt-1 bg-indigo-50 placeholder:text-sm"
            />
          </div>
          <div className="mt-5 grid grid-cols-6 items-center">
            <label
              htmlFor="password"
              className="text-sm text-neutral-500 col-span-2"
            >
              New Password
            </label>
            <input
              type="password"
              id="password"
              placeholder="Enter new password"
              className="col-span-4 border border-neutral-200 rounded px-3 py-1 mt-1 bg-indigo-50 placeholder:text-sm"
            />
          </div>
          <div className="mt-5 grid grid-cols-6 items-center">
            <label
              htmlFor="confirm-password"
              className="text-sm text-neutral-500 col-span-2"
            >
              Confirm Password
            </label>
            <input
              type="password"
              id="confirm-password"
              placeholder="Confirm new password"
              className="col-span-4 border border-neutral-200 rounded px-3 py-1 mt-1 bg-indigo-50 placeholder:text-sm"
            />
          </div>
        </div>
      </div>
    </section>
  );
}
