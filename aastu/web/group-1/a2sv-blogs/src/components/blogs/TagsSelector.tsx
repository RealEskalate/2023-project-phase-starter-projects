type Props = {
  selectedTags: string[];
  setSelectedTags: (tags: string[]) => void;
};

const TagSelectionForm: React.FC<Props> = ({
  selectedTags,
  setSelectedTags,
}) => {
  const availableTags = [
    "Development",
    "Sports",
    "Writing",
    "Self-Improvement",
    "Technology",
    "Social",
    "Data Science",
    "Programming",
  ];

  const handleTagChange = (tag: string) => {
    if (selectedTags.includes(tag)) {
      setSelectedTags(
        selectedTags.filter((selectedTag) => selectedTag !== tag)
      );
    } else {
      setSelectedTags([...selectedTags, tag]);
    }
  };

  return (
    <div className="flex flex-col gap-4">
      <h3 className="font-bold">Select Tag</h3>
      <div className="flex flex-wrap gap-2">
        {availableTags.map((tag) => (
          <label
            key={tag}
            className={`font-montserrat text-sm flex items-center rounded-full border py-1 px-4 ${
              selectedTags.includes(tag)
                ? "border-blue-500 bg-blue-100 font-bold"
                : "border-gray-300 bg-gray-200"
            }`}
          >
            <input
              type="checkbox"
              checked={selectedTags.includes(tag)}
              onChange={() => handleTagChange(tag)}
              className="sr-only"
            />
            <span>{tag}</span>
          </label>
        ))}
      </div>
    </div>
  );
};

export default TagSelectionForm;
