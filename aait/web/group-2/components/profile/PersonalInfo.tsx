export default function PersonalInfo() {
    const style = "border border-slate-200 text-black px-7 py-1 rounded-md m-5";
    return (
      <div className="ml-8">
        <div className="flex justify-between mt-8 my-4 border-b border-slate-100 pb-4">
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
        <form className="w-3/4">
          <div>
            <label>
              Name <b className="text-red-700 pr-20">*</b>
            </label>
  
            <input
              type={"password"}
              placeholder="FirstName"
              className={style}
            ></input>
            <input
              type={"password"}
              placeholder="LastName"
              className={style}
            ></input>
          </div>
          <div>
            <label>
              Email <b className="text-red-700 pr-20">*</b>
            </label>
            <input
              type={"Email"}
              placeholder="email"
              className={`w-7/12 ${style}`}
            ></input>
          </div>
          {/* <div>
            <label>
              Pic <b className="text-red-700 pr-16">*</b>
            </label>
            
          </div> */}
          <div className="flex items-center space-x-8 pt-6">
            <label className="inline">
              Your Photo <b className="text-red-700 pr-8">*</b>
            </label>
            <div className="shrink-0">
              <img
                className="h-16 w-16 object-cover rounded-full"
                src="https://images.unsplash.com/photo-1580489944761-15a19d654956?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1361&q=80"
                alt="Current profile photo"
              />
            </div>
            <div className="flex items-center justify-center w-6/12 h-1/3">
              <label
                htmlFor="dropzone-file"
                className="flex flex-col items-center justify-center w-full h-28 border border-gray-300 rounded-lg cursor-pointer hover:bg-gray-100"
              >
                <div className="flex flex-col items-center justify-center pt-5 pb-6">
                  <svg
                    className="w-8 h-8 mb-4 text-blue-500 dark:text-gray-400"
                    aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 20 16"
                  >
                    <path
                      stroke="currentColor"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M13 13h3a3 3 0 0 0 0-6h-.025A5.56 5.56 0 0 0 16 6.5 5.5 5.5 0 0 0 5.207 5.021C5.137 5.017 5.071 5 5 5a4 4 0 0 0 0 8h2.167M10 15V6m0 0L8 8m2-2 2 2"
                    />
                  </svg>
                  <p className="mb-2 text-sm text-gray-500 dark:text-gray-400">
                    <span className="font-semibold">Click to upload</span> or drag
                    and drop
                  </p>
                  <p className="text-xs text-gray-500 dark:text-gray-400">
                    SVG, PNG, JPG or GIF (MAX. 800x400px)
                  </p>
                </div>
                <input id="dropzone-file" type="file" className="hidden" />
              </label>
            </div>
          </div>
        </form>
      </div>
    );
  }
  