using RentACarSimulation.Models;

namespace RentACarSimulation.Repository;

public class ColorRepository
{
    List<Color> colors = new List<Color>()
    {
    new Color(1, "Sarı"),
    new Color(2, "Kırmızı"),
    new Color(3, "Yeşil"),
    new Color(4, "Kahverengi"),
    new Color(5, "Gri"),
    new Color(6, "Beyaz"),
    new Color(7, "Mavi"),
    new Color(8, "Turkuaz"),
    new Color(9, "Ela"),
    new Color(10, "Lila"),
};

    public List<Color> GetAll()
    {
        return colors;
    }

    public Color Add(Color created)
    {
        colors.Add(created);
        return created;
    }

    public Color? Remove(int id)
    {

        Color? removedColor = GetById(id);

        if (removedColor is null)
        {
            return null;
        }
        colors.Remove(removedColor);
        return removedColor;

    }

    public Color? Update(Color updatedColor)
    {
        {
            Color? existingColor = GetById(updatedColor.Id);
            {
                if (existingColor is null)
                {
                    return null;
                }
                return updatedColor;
            }
        }
    }

    public Color? GetById(int id)
    {
        Color? color1 = null;
        foreach (Color color in colors)
        {
            if (color.Id == id)
            {
                color1 = color;
            }
        }

        if (color1 == null)
        {
            return null;
        }

        return color1;
    }
}