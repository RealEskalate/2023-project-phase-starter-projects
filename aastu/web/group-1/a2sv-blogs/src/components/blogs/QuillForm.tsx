import "react-quill/dist/quill.snow.css";
import dynamic from "next/dynamic";

const DynamicReactQuill = dynamic(() => import("react-quill"), {
  ssr: false,
  loading: () => <p>Loading...</p>,
});

type Props = {
  description: string;
  setDescription: (description: string) => void;
};

const CreateForm: React.FC<Props> = ({ description, setDescription }) => {
  const modules = {
    toolbar: [
      [{ header: "1" }, { header: "2" }, { font: [] }],
      [{ size: [] }],
      ["bold", "italic", "underline", "strike", "blockquote"],
      [
        { list: "ordered" },
        { list: "bullet" },
        { indent: "-1" },
        { indent: "+1" },
      ],
      ["link", "image", "video"],
      ["clean"],
    ],
    clipboard: {
      matchVisual: false,
    },
  };
  const formats = [
    "header",
    "bold",
    "italic",
    "underline",
    "strike",
    "blockquote",
    "list",
    "bullet",
    "indent",
    "link",
    "image",
  ];

  return (
    <DynamicReactQuill
      theme="snow"
      value={description}
      onChange={(value: string) => setDescription(value)}
      modules={modules}
      formats={formats}
      className="border-l-4 border-primary"
    />
  );
};

export default CreateForm;
