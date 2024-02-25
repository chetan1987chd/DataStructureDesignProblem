/// <summary>
/// Represents a file system that stores file paths and their corresponding values.
/// </summary>
//Leetcode : 1166// https://leetcode.com/problems/design-file-system/submissions/1185417540/
public class FileSystem {

    Dictionary<string,int> filePaths = new Dictionary<string, int>();

    /// <summary>
    /// Initializes a new instance of the <see cref="FileSystem"/> class.
    /// </summary>
    public FileSystem() {
        
    }
    

    /// <summary>
    /// Creates a new file path with the specified value.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="value">The value associated with the file path.</param>
    /// <returns><c>true</c> if the file path is created successfully; otherwise, <c>false</c>.</returns>
    public bool CreatePath(string path, int value) {
        
        if(!CheckIfValidPath(path))
        {
            return false;
        }

        string parent = path.Substring(0,path.LastIndexOf("/"));

        if(!string.IsNullOrEmpty(parent) && !filePaths.ContainsKey(parent))
        {
            return false;
        }

        if(!filePaths.ContainsKey(path))
        {
            filePaths.Add(path,value);
            return true;
        }

        return false;

    }
    
    /// <summary>
    /// Gets the value associated with the specified file path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>The value associated with the file path, or -1 if the file path does not exist.</returns>
    public int Get(string path) {
        if(filePaths.ContainsKey(path))
        {
            return filePaths[path];
        }
        return -1;
    }

    private bool CheckIfValidPath(string path)
    {
        if(!path.Contains("/") || string.IsNullOrEmpty(path))
        {
            return false;
        }
        return true;
    }
}
