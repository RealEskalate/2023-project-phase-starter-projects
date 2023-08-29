const QuillToolbar = () => (
  <div
    id="toolbar"
    className="flex justify-evenly !border-0 !border-t !border-b py-3"
  >
    <div className="flex items-center w-full">
      <div className="border-r pr-2 ">
        <div className="bg-[#63A2D8] rounded w-6 h-6" />
      </div>
      <div className=" border-r flex justify-center md:px-2">
        <button className="ql-bold font-bold ml-4" />
        <button className="ql-italic" />
        <button className="ql-underline mr-4" />
      </div>
      <div className="border-r flex justify-center md:px-2">
        <button className="ql-list" value="bullet" />
        <select className="ql-align"></select>
      </div>
      <div className="border-r flex justify-center md:px-2">
        <button className="ql-link" />
      </div>
    </div>
    <div className="col-span-3 flex w-full justify-end px-2">
      <div>
        <button className="ql-video" />
        <button className="ql-image" />
      </div>
    </div>
  </div>
);

export default QuillToolbar;
